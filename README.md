# Kata

## **Objectifs**

- Montrer ce que vous savez faire dans un temps raisonnable et voir comment vous codez dans la vrai vie.
- Faire une PR sur la branche **main** afin que nous puissions te faire des commentaires.
- Il s’agit d’un projet que devrait bientôt partir en **production** en ce qui concerne à la qualité du code.

Dans le cadre de ce projet, nous souhaitons avoir une Api :

1. Je veux que mon sensor récupère la température provenant du composant `TemperatureSensor` (renvoi la température en degrés Celsius).
2. Je veux que l'état de mon Sensor soit à "HOT" lorsque la température captée est supérieure ou égale a 35 °C.
3. Je veux l'état de mon Sensor soit à "COLD" lorsque la température captée est inférieur a 22°C.
4. Je veux l'état de mon Sensor soit à "WARM" lorsque la température captée est entre 22°C et inférieur à 35 °C.
5. Je veux récupérer l'historique des quinze dernières demandes des températures.
6. Je veux pouvoir redéfinir les limites pour "HOT", "COLD", "WARM".

## **Stack Obligatoire**

- .NET Core 6 ou supérieur
- SQL Lite
- Docker
------------------------------------------------------------------------------------------------------------------------------------------------

** Actions à faire ou faites - Bloc-note brouillon **

## Conception
- Design de l'Architecture : Réfléchir à la structure générale du projet.
- Préparation des Interfaces : Définir et préparer les interfaces nécessaires.
- Implémentation : Planifier les méthodes d'implémentation.

## Préparation de l'Environnement

- Mise à jour de la CLI Angular : Actualiser la version de la CLI Angular pour assurer la compatibilité.
  - Gérer les avertissements de version entre la version globale et locale de Angular CLI.
  - Résoudre les problèmes de compatibilité de Node et Angular.
    
## Développement et Débogage
- Mise à jour du Projet Local : Supprimer node_module et package-lock.json, nettoyer et vérifier le cache npm, puis réinstaller les dépendances.
- Tests et Lancement du Projet : Exécuter des tests avec Jasmine et démarrer le projet pour vérifier la fonctionnalité.
- Gestion des Avertissements et Erreurs : Adresser les avertissements liés à Angular et planifier des mises à jour futures.

## Architecture de Communication
- Infrastructures de Communication : Mettre en place une infrastructure simple avec des itérations pour amélioration.
   - Créer un programme pour la communication entre différents daemons (Web, Sensor externe, Sauvegarde de messages).
- Gestion de Queue Partagée : Utiliser une queue thread-safe et implémenter des fonctions de publication et de consommation de messages.
- Intégration et Tests de Queue : Intégrer la queue dans l'application et tester son fonctionnement avec différents consommateurs.

## Développement API et Base de Données
- Modèles et Entités : Définir les modèles de domaine (mesures, indicateurs, sources, seuils).
- Configuration de Base de Données : Configurer SQLite, créer des scripts pour la gestion de la base de données.
- Création et Gestion des Tables : Établir et gérer les tables nécessaires dans SQLite.
- Développement des Contrôleurs et Services : Compléter les contrôleurs API et préparer des tests CRUD avec Postman.
- Gestion des Erreurs API : Mettre en place des directives pour le design de l'API, y compris la gestion des erreurs.

## Problèmes Rencontrés et Résolus
- Mise en place du bus orienté topic plustot que qeuue. un bus ou s'il y'a un producteur les nouveau consomateur ne recuperent pas le flux/l historique
- la modelisation du bus pour que les consomateur recoivent le meme message
- Integrer le bus comme singleton entre les process
- Modelisation du domain surtout la partie measure, j'aurais pu partir sur un modele simple non composé mais j'ai preferé aller sur une bonne modelisation
- gestion des repository et surtout la partie mapping des donnée externe vers le modele qui propose des setter privé, l'automapper est utilisé avec le constrcuteur de destination
- probleme de mise en place de dapper avec sql lite, il fallait resoudre quelque problemes
- j'ai hestié a afficher tout cela sur une console mais j'ai preferé le faire sur angular
- Gestion des Versions et Compatibilité : Résolution des incompatibilités entre les versions globales et locales de Angular CLI et Node.
- Problèmes d'Intégration : Résoudre les problèmes d'intégration entre différentes composantes et services.
- commencer a tester le domain avant les autres couches, car ils sont potentiellement deja testé comme dapper , pas besoin de le restester...
  
## Réflexions Techniques
- Choix des Technologies : Angular, SQLite, webapi mvc 6 ,Dapper
- Architecture et Design : je suis parti sur du DDD , Hexa on essayer de modiliser le domaine des capteurs, on peut avoir plusieurs capteur qui se se connectent sur le systeme pour pusher et non le systeme qui se connecte sur eux,
d'ailleurs il peuvent etre en veille, c'est a eux de pusher et non a la centrale de puller
- l'etat se met a jour a chaque fois qu'on recoit un message et non pas a chaque fois qu'on recoit une requete de consultation. l'etat est deduit automatiquement et se fait dans un service dedié pour le changement d'etat.
  ici mon etat n'est pas immutable j'aurais pu faire comme rxjs mais j'ai fais ce que j'ai pu avec l'oganisation que j'ai.

## Optimisations, reste a faire et Améliorations Futures
- revoir tous les services et rajouter le mode async/await cela monter depuis dapper vers le controller sinon cela ne sert a rien, il fauda utiliser queryAsync
- revoir le modele de retour, pour la pagination par example, il faut faire un model Page et dedans des Items[]
- mettre en place swagger pour faciliter les test
- mettre en place le versionning api/v1/totot
- dans controller utiliser le cancelToken dans les operations car il peut y avoir des coupure de sessions
- gerer les exception, pour le moment les exception ne pas correctement genré, il faut specifier les exception IndicationNotFoundException
- integrer le logger car je l'ai pas fais je me suis plus focaliser sur le metier et la feature qui est afficher l historique de 15 et le state sur une page
- utiliser websocket , signal pour notifier/pusher etat vers la page, faire des pull tous les x second n'est pas bon
- gerer la configuration correctement car la j'ai mis pas mal de choses en dure
- envoyer les bons code d'errur vers les client, la j'ai mis badrequest dans les exception, mais il faut mettre internal server errror=> si erreur requete format alors code 40x sinon si 50x 
- faire evoluer l'interface graphque, il faudra rajouter un select pour les indicator, un select pour les source = sensor comme ca on pourra voir les diffrentes measures recu par un capteur
- il faut revoir le message envoyer par les capteurs et reformater pour qu'il suit le mode domain qu'ona fait - j'ai pas assez de temps pour le faire
- la configuration , on devrait avoir un repertoire config pour chaque environement qui contient le appsetting de chaque environement avec les variables macro qui seront plus tard remplacé avec les bonne valeurs venant des agents delivraison dev,rec,med,prod

  ## Manque de connaissance mais surmontable
  - Docker, j'ai installé les outils sur ma machine et generé les fichiers car c'est indiqué Obligatoire dans la feature. ce n'est qu'une histoire de 1 ou 2 jours pour etre operationnel dessus. Merci pour votre comprehension

  
## DDD / Hexa projet api = Sensor 

=> le domaine ne depend pas des autres couche, meme pas via l'automapper, les setter du domaine sont privés

Application
- Sensor : Ce projet pourrait être l'application centrale qui coordonne les opérations. Il peut contenir des éléments tels que des cas d'utilisation, des commandes, des événements, et la logique qui orchestre le déroulement des fonctionnalités de l'application.

Domain
- Sensor.Domain : Contient les entités, les objets de valeur, les agrégats, les exceptions du domaine et les interfaces des services du domaine qui modélisent les concepts du domaine métier et les règles métier.
- Sensor.Domain.Impl : Implémentation concrète des interfaces définies dans Sensor.Domain. Cela comprend la logique métier et les règles qui ne sont pas forcément liées à la persistance ou à l'infrastructure.

Infrastructure
- Sensor.Infrastructure : Contient la logique d'accès aux mécanismes de bas niveau tels que la base de données, le file system, les services web externes, etc.
- Sensor.Infrastructure.Impl : Implémentation concrète des interfaces définies dans Sensor.Infrastructure. Cela pourrait inclure les détails d'implémentation des adaptateurs pour la persistance, l'envoi de messages, etc.

Presentation
- Sensor.Presentation.Mom.Services : Peut représenter la partie Middleware Oriented Message des services de présentation, gérant la communication asynchrone et l'orchestration des messages
- Sensor.Presentation.Rest.Services : La couche de présentation pour les services REST, responsables de gérer les requêtes HTTP, de formater les réponses et d'interagir avec les utilisateurs ou les systèmes externes.

Test
- Sensor.Domain.Test : Tests unitaires ou d'intégration spécifiques au domaine métier.
- Sensor.Infrastructure.Test : Tests axés sur l'infrastructure pour vérifier l'intégration avec les bases de données, les services externes, etc.

Util
- Sensor.CrossCutting : Contient des préoccupations transversales telles que la journalisation, la configuration, la sécurité, ou tout autre aspect qui coupe à travers les différentes couches de l'architecture.

Chaque "couche" ou "module" est séparé des autres, favorisant ainsi le découplage et la séparation des préoccupations. Les dépendances sont dirigées de l'extérieur vers le domaine, et non l'inverse, ce qui permet de conserver une isolation du domaine métier par rapport aux détails techniques.

## Gestion sql 

Sensor.Sql 
 - contient les fichier des cration des tables , shema et principalement les migrations indexé. l'sql est basé sur le lancement du diff
 - Source   : peut etre un sensor, un radiateur, une sonde, une telecomannde, l'important c'est quelle envoi un format de message unique qui indique une metriqiue bien precise
 - Measure  : un metrique est en fait une valeur qui est lié a un Indicateur et une Source. Qulles sont les metrique envoyé par tel ou tel capteur ?
 - Indicator: donne une caracteristique de l'information qu'on envoi , un indicateur de categorie chaleur dédié pour la temerateure et non a l humidite
 - threshol : les limites indiqué par l'utilisateur mais en fait ca devrait representé les regles
   
 ![image](https://github.com/harvest-ext/quantalys-temperature-sensor-cherry-pick-mahmoud-hammouda/assets/50197626/a343505a-f240-49e6-a31a-de3ba4e294a2)

-> ici j'ai un probleme l'unité dans le modele doit etre sur l'indicateur ( a revoir)
## tests acceptances

Sensor.Acceptances
 - Contient les fichiers de test postamn pour les gens du metier qui devron etre automtisé sur le cicd si biensure on les developpe pas via le c#

 ## Comment tester

Au démarrage de l'application, nous initialisons une instance d'un bus de messages. Ce bus est configuré avec des consommateurs abonnés à différents topics. Un consommateur est chargé d'imprimer les messages envoyés dans un topic spécifique, tandis qu'un autre, interne à l'API, est responsable de la mise à jour de la table historique des mesures.

Chaque consommateur reçoit en entrée une classe Handler. La logique de traitement des messages est définie à l'extérieur et injectée dans le consommateur, permettant ainsi au Handler d'interagir directement avec le domaine métier.
Initialement, l'application dispose d'un seul producteur, typiquement un capteur (sensor), mais elle est conçue pour être extensible : il est possible d'ajouter plusieurs capteurs et de créer de multiples topics si nécessaire.
Lorsque les messages sont envoyés, ils sont reçus par le consommateur interne de l'API qui effectue non seulement la mise à jour de la base de données avec les nouvelles mesures mais s'occupe également de mettre à jour l'état du système. Cet état peut évoluer entre différents seuils tels que HOT, WARN, ou COLD, en fonction des données reçues, permettant ainsi un suivi en temps réel des conditions surveillées par les capteurs.


![image](https://github.com/harvest-ext/quantalys-temperature-sensor-cherry-pick-mahmoud-hammouda/assets/50197626/0427b664-c7a6-49dd-8f5f-830fe2b409db)

-> ici l'etat ne s'affiche pas , je vais fixer mais sur postam ca marche bien

![image](https://github.com/harvest-ext/quantalys-temperature-sensor-cherry-pick-mahmoud-hammouda/assets/50197626/f38ef06a-6c3a-4c84-8515-bfa6735f2d4c)

fixed avant minuit :)
![image](https://github.com/harvest-ext/quantalys-temperature-sensor-cherry-pick-mahmoud-hammouda/assets/50197626/aa570286-753d-4794-87f0-eb318a2aac7e)


Merci pour cette excercice, ca m'a permis de voir un peu mes limites dans un temps courts de moins de deux jours





