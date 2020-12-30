# **Rapport**

Dans le cadre du cours de “Programmation Orienté Objet”, nous avons développé une plateforme de simulation de réseau électrique afin de pouvoir simuler le comportement dynamique d’un ensemble de centres de production d’électricité et d’un ensemble de consommateurs. Pour ce faire nous avons utilisé le langage de programmation C#.

## **Classes :**

Les classes et interface utilisées dans ce projet sont les suivantes :

- *Network :*

Contrôle tout le réseau électrique regroupant les nœuds, les lignes dans des dictionnaires, un objet météo. C’est dans cette classe que l’on va pouvoir réaliser la simulation.

- *Line* :

Permet de lier deux éléments du réseau. Chaque ligne est composée d’une puissance maximale, d’une puissance de ligne, d’un id unique, d’un état d’activité sur le réseau et d’un état de connexion (en entrée et en sortie).

- *Node :*

Tous les éléments que l’on peut rajouter dans le réseau (mis à part les lignes) sont des objets de type nœud. Ils sont caractérisés par une puissance, un id unique et un état d'activité sur le réseau. Un nœud contient la ligne à laquelle il est connecté.

- *ConsumerNode :*

Ce sont des nœuds de type consommateurs. Il y a des sous classes de consommateurs comme les villes (Town), les entreprises (Company), les dissipateurs (Dissipator) où des consommateurs étrangers (ExportCountry). 

- *DistributionNode :*

Ce sont des nœuds qui permettent d’envoyer sur plusieurs lignes l’énergie qu’ils reçoivent sur leur unique entrée et ce de manière équivalent sur chaque sortie.

- *ConcentrationNode :*

Ces nœuds permettent de concentrer l’énergie provenant de plusieurs lignes en entrée afin de sortir sur une unique ligne la somme totale des énergies qu’il a reçu.





- *PowerStationNode :*

Cette classe concerne des sources de production d’électricité telles que les centrales au gaz (GasPS), les énergies solaire (SolarPS), les parcs éolien (WindPS), les centrales nucléaire (NuclearPS) et l’achat d’électricité à l’étranger (ImportCountry) qui a la particularité de ne pas avoir une production maximale fixe. Les autres sources ont une production maximale fixe et peuvent avoir une production d’énergie constante et/ou variable et/ou dépendant de la météo.

- *Fuel :*

Classe qui permet de spécifier le type de carburant de chaque centrale de production ainsi que son prix et la pollution et son énergie produite par unité.

- *Weather :*

Classe permettant de paramétrer et simuler la météo pour les centrales solaires et le parc éolien.

- *UpdatableComponent :*

Interface qui permet de mettre à jour un l’élément qui l’implémentent.

**Fonctionnalités :**

- Création d’un réseau électrique permettant de contenir des objets (lignes et nœuds).

- Fonction permettant de rajouter les éléments sur le réseau (les nœuds de distribution et de concentration, les consommateurs et les sources). L'attribution des ids des objets du réseaux est entièrement gérer par le réseau et de manière automatique.

- Fonction de mise à jour de tous les éléments qui composent le réseau.
- Simuler une demande variable des consommateurs.

- Fonction qui permet de répondre à la demande d’énergie des consommateurs avec une gestion basique des priorités au niveau du choix des sources de production d’énergie à modifier.

- Une fonctionnalité de météo associé au réseau entièrement paramétrable sur l’intensité lumineuse et le vent pour simuler les productions d’énergie des sources de production dépendante de la météo.







- Des nœuds de concentration permettant de regrouper plusieurs entrées et combiner leur puissance en une unique sortie.

- Des nœuds de distribution permettant de distribuer de manière équitable l’énergie reçu sur son unique entrée vers ces différentes sorties.

- Des consommateurs dont leur consommation électrique est modifiable (villes, entreprises, dissipateurs et export vers les pays étrangers).

- Des sources qui permettent de fournir de l’énergie a des consommateurs (centrales à gaz, centrales nucléaires, panneaux solaires et parcs éoliens). Une source peut être une combinaison des 3 caractéristiques suivantes : flexible, dépendant de la météo et infini.

- Fonction permettant de connecter différents éléments au moyen de ligne.

- Possibilité de mettre à jour le coût du carburant suivant les prix du marché.

- Possibilité d’ajouter une source de stockage.

**Organisation du code :**

Le code est divisé en un dossier main, qui contient le fichier *Progam.cs* et la classe Network qui donne accès à tous les outils pour créer un réseau et des objets. Il y a 4 dossiers *Consummer*, *PowerStation*, *Distribution et* Concentration reprenant respectivement les 4 grandes classes de nœuds (consommateur, source, nœud de distribution et concentration)

La structure du stockage des différents éléments du réseaux se fait au moyen de dictionnaires. On y ajoute chaque objet et son id associé (généré automatiquement par le réseau) dans cette structure de donnée. Il y a 4 dictionnaires au total. Les consommateurs et les sources d’énergie sont préalablement séparés dans 2 dictionnaires indépendants. Il y a un dictionnaire principal contenant tous les objets de type nœud et un dictionnaire contenant toutes les lignes.

Dans le *Program.cs*, on crée le réseau et on y ajoute les éléments souhaités. On lance la simulation au moyen de la méthode *run* du réseau qui s’occupe de mettre à jour la production d’énergie en fonction de la consommation énergétique des consommateurs. Cette méthode *run* sera appelée toutes les secondes au moyen de la librairie *Timer* dans la fonction *OnTimeEvent*.

Au terme de chaque *run,* la mise à jour des éléments du réseau est réalisée par la méthode *updateNetwork.* Cette dernière met à jour toutes les lignes du réseau en appelant les méthodes update des nœuds qu'elle relie. On met évidemment à jour uniquement les lignes qui sont connectées des deux côtés. Les lignes et les nœuds implémentent toutes et tous l’interface *IUpdatableComponent.* 

La mise à jour des lignes se fait dans un ordre spécifique afin de respecter certaines conditions. En effet il faut s’assurer que le nœud à l’entrée d’une ligne a déjà été mis à jour avant de mettre à jour le nœud à la sortie. Ce sont les nœuds qui appellent la méthode *update* de la ligne qui met à jour sa puissance transmise tout en vérifiant qu’elle ne dépasse pas sa capacité maximale auquel cas la ligne affichera un message d’erreur et changera son état *nodeState* en inactif.

Concernant les nœuds de concentration, on va additionner les puissances qu’ils reçoivent en entrée pour l’envoyer vers la ligne de sortie. Quant aux nœuds de distribution, on va diviser leur puissance d’entrée entre toutes les sorties de manière équivalente.

Pour les différents consommateurs du réseau, on réceptionne l’énergie de la ligne et on vérifie si cette énergie est supérieure à la demande, auquel cas on envoie un signal d’erreur et on passe l’état *nodeState* en inactif.

Finalement, pour les centrales de production, on actualise la production en allumant ou éteignant des centrales. On vérifie aussi qu’elles sont les conditions météorologiques (vent, soleil) pour actualiser la production des centrales dépendante de la météo. En fonction de cette nouvelle production, on calcule le cout et l’émission de CO2.

Le réseau simule une demande et décide ensuite quelles sources activer ou éteindre afin d’augmenter ou diminuer la production et satisfaire ainsi la demande. Pour ce faire il change la production selon des priorités prédéfinies. 

Dans le cas où la demande est supérieure à l’offre, on diminue en priorité la dissipation d’énergie, ensuite on peut modifier la production provenant des énergies renouvelables. Si ça ne suffit pas, on augmente la production des centrales qui sont flexibles, et en ultime recourt on comble le manque par l'importation d’énergie. 

Cependant, si l’offre est plus grande que la demande, on diminue l’importation d’énergie en priorité.  S’il y a surplus, on réduit la production des centrales flexibles indépendantes de la météo, puis les énergies renouvelables et en dernier recourt on redirige l'énergie vers des dissipateurs. La possibilité de stocker l’énergie est envisagée mais non implémentée dans le simulateur.





**Commandes :**

**Création de réseau :**

- Pour créer un réseau, nous utilisons cette commande ci :

![](Rapport%20POO.001.png)

- Ensuite, dans ce réseau, nous créons des centrales de production d’électricité. En paramètre de celles-ci, nous ajoutons le type de centrale avec sa production maximale et son carburant (le carburant prenant en paramètre un prix, une émission de CO2 et une production par unité). Pour les centrales dépendant de la météo, nous ajoutons en paramètre la météo liée au réseau.![](Rapport%20POO.002.png)
- Puis, nous créons des consommateurs avec en paramètre leur type ainsi que leur demande d’électricité.![](Rapport%20POO.003.png)
- Par après, nous créons des nœuds de distributions et des nœuds de concentration grâce à ces commandes-ci :![](Rapport%20POO.004.png)
- Les lignes peuvent ensuite être créées. Celles-ci prennent en paramètre leur puissance maximale.![](Rapport%20POO.005.png)
- Enfin, nous pouvons connecter les nœuds désirés entre eux grâce à la commande ci-dessous. Elle prend en paramètre un nœud d’entrée et un nœud de sortie, ainsi que l’id de la ligne.![](Rapport%20POO.006.png)

**Modification ou perturbation du réseau :**

- Pour modifier la production d’une centrale de production nous utilisons cette commande. Celle-ci prend l’id de la centrale recherchée et en paramètre la nouvelle puissance voulue. Une centrale se met à l’arrêt lorsque la production est mise à 0 et elle redémarre lorsqu’on lui fourni une quantité supérieure à 0.![](Rapport%20POO.007.png)
- Nous pouvons aussi arrêter n’importe quelle station grâce à cette fonction :
- Pour modifier la demande d’électricité d’un consommateur, cette commande-ci est appliquée. Elle prend en paramètre la puissance demandée.![](Rapport%20POO.008.png)
- Afin de modifier la production d’une centrale ou la demande d’électricité d’un consommateur à un temps donné (en ms), nous utilisons cette commande en combinaison avec l’une des commandes ci-dessus.![](Rapport%20POO.009.png)
- Nous pouvons aussi changer la météo du réseau (l’intensité du vent et lumineuse peut varier entre 0 et 100).![](Rapport%20POO.010.png)
- Le prix du carburant peut prendre une nouvelle valeur grâce à cette commande.![](Rapport%20POO.011.png)

**Lancement et mise à jour de la simulation :**

- La commande *Run* nous permet de lancer la simulation une fois.![](Rapport%20POO.012.png)
- La commande *Start* nous permet de lancer la méthode *run* qui sera appelée toutes les secondes. Pour stopper la simulation, il suffit d’appuyer sur la touche « Enter » du clavier.![](Rapport%20POO.013.png)
- La commande *Update*, nous permet de mettre à jour tout réseau.![](Rapport%20POO.014.png)

**Diagrammes :**

- Diagramme de classe : <https://lucid.app/lucidchart/invitations/accept/c70c3df0-3a74-478b-8c72-c87c4ec8c674> 

- Diagramme de séquence : 




PAGE   \\* MERGEFORMAT2


