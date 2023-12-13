using Microsoft.AspNetCore.Http.Json;
using Sensor.Domain.Impl.Services;
using Sensor.Domain.Services;
using Sensor.Infrastructure.Bus;
using Sensor.Infrastructure.Bus.Model;
using Sensor.Infrastructure.Impl.Bus;
using Sensor.Infrastructure.Impl.Repository;
using Sensor.Infrastructure.Repository;
using System;
using System.Collections.Concurrent;
using System.Data.SQLite;
using System.Data;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using Sensor.Presentation.Mom.Services.Services;
using Sensor.Infrastructure.Cache;
using Sensor.Infrastructure.Impl.Cache;
using Microsoft.Win32;
using System.Xml.Linq;

namespace Sensor
{


    class Program
    {
        static void Main(string[] args)
        {
            Debug.AutoFlush = true;
            Debug.Indent();
            Debug.WriteLine("Entering Main");
           
            // CREATE AN INNER TOPIC SETVICE DRIVEN BY CONSUMER - BUS - TOPIC MULTI CONSUMER 
            IBus<SensorMessage> queueService = new SensorTopicBus();


            // IMPOTANT : NEED TO START CONSUMER BEFORE PRODUCER
            //----------------------------------------------------------------------------------
            // CREATE EXTERNAL CONSUMERS FOR THE TOPIC TO PRINT RECEIVED MESSAGE - ONLY FOR TEST
            // BUT COULD USE IT FOR SEVERAL THING ASYNC THINGS
            Task.Run(() => RunConsumerApplications(args, queueService));
            Task.Delay(5000);

            // CREATE SENSOR/SOURCE APPLICATIN - SOURCE MESASGE PRODUCER
            // SOURCE COULD BE SENSOR
            Task.Run(() => RunSourceApplications(args, queueService));
            
            // CREATE MY WEB APPLICATION AND START IT
            RunWebApiApplication(args, queueService);

        }

        static void RunWebApiApplication(string[] args, IBus<SensorMessage> bus)
        {
            var builder = WebApplication.CreateBuilder(args);

            // CONFIGURE THE REPONSE FORMAT - API
            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            }); ;

            // REGISTER AUTOMAPPER
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            // REGISTER BUS SERCICEE
            builder.Services.AddSingleton(typeof(IBus<SensorMessage>), bus);


            // REGISTER CACHE SERCICEE
            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<ICache, MemoryCache>();

            // REGISTER DOMAIN SERCICEE
            builder.Services.AddScoped<IIndicatorService, IndicatorService>();
            builder.Services.AddScoped<IMeasureService, MeasureService>();
            builder.Services.AddScoped<IThresholdService, ThresholdService>();
            builder.Services.AddScoped<IStateService, StateService>();
            //builder.Services.AddScoped<ISourceService, SourceService>();

            // REGISTER INFRA SERCICEE
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(DapperGenericRepository<>));
            builder.Services.AddScoped<IIndicatorRepository, IndicatorRepository>();
            builder.Services.AddScoped<IMeasureRepository, MeasureRepository>();
            builder.Services.AddScoped<ISourceRepository, SourceRepository>();
            builder.Services.AddScoped<IThresholdRepository, ThresholdRepository>();


            // REGISTER SQL DATABASE
            SQLitePCL.Batteries.Init();
            builder.Services.AddScoped<IDbConnection>((sp) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                return new SqliteConnection(configuration.GetConnectionString("SQLiteConnection"));
            });


           var app = builder.Build();

            // REGISTER INTERNANAL CONSUMER SERVICE + SUBSCRITION TO THE SINGLETON INJECTED BUS
            var serviceProvider = app.Services;
            using (var scope = serviceProvider.CreateScope())
            {
                var measureService = scope.ServiceProvider.GetRequiredService<IMeasureService>();
                var stateService = scope.ServiceProvider.GetRequiredService<IStateService>();
                IConsumer<SensorMessage> apiConsumer1 = new SensorConsumer("ApiConsumer1", new SenorMessageHandler(measureService, stateService));
                bus.Subscribe("tempertureTopic", apiConsumer1);
            }



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();

        }

        static void RunSensor(string name, string topic, IBus<SensorMessage> bus)
        {
            var random = new Random();
            var timer = new Timer(_ =>
            {
                int temperature = random.Next(-10, 41);
                bus.Publish(topic, new SensorMessage(name, temperature, DateTime.UtcNow));
                //bus.Publish("sensorEvent2", new SensorMessage("Pioneer2", temperature, DateTime.UtcNow));
                Console.WriteLine($"temeratur message sent : {temperature}°C");
            },
            null,
            TimeSpan.Zero,
            TimeSpan.FromSeconds(1));

        }

        static void RunSourceApplications(string[] args, IBus<SensorMessage> bus)
        {
            RunSensor("Pioneer2", "tempertureTopic", bus);
            //RunSensor1("other", "tempertureTopic", bus);
        }

        static void RunConsumerApplications(string[] args, IBus<SensorMessage> bus)
        {
            // Consumer listner moom/queue and use IBus to sub/receive
            IConsumer<SensorMessage> consumer1 = new SensorConsumer("consumer1", new ConsoleMessageHandler());
            bus.Subscribe("sensorEvent1", consumer1);


            // Consumer listner moom/queue and use IBus to sub/receive
            IConsumer<SensorMessage> consumer2 = new SensorConsumer("consumer2", new ConsoleMessageHandler());
            bus.Subscribe("sensorEvent1", consumer2);

        }
    }

    public class ConsoleMessageHandler : IMessageHandler
    {
        public void HandleMessage(SensorMessage message)
        {
            Debug.WriteLine("message from sensorName :" + message.SensorName + "   timestamp:" + message.ObservationTime + "    received temperature:" + message.Temperature);
        }
    }


}
