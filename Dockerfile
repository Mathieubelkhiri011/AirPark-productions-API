# Etape 1 : Build
FROM maven:3.8.5-openjdk-17-slim AS build

# Définir le répertoire de travail
WORKDIR /app

# Copier le fichier de configuration Maven
COPY pom.xml .

# Télécharger les dépendances sans construire le projet pour optimiser le cache Docker
RUN mvn dependency:go-offline -B

# Copier le reste du projet dans le conteneur
COPY . .

# Compiler le projet et créer le fichier JAR avec des logs détaillés
RUN mvn clean package -DskipTests -e -X

# Étape 2 : Exécution
FROM openjdk:22-jdk-slim

# Définir le répertoire de travail
WORKDIR /app

# Copier le fichier JAR de l'étape de construction
COPY --from=build /app/target/*.jar app.jar

# Exposer le port 8080
EXPOSE 8080

# Définir la commande de démarrage
CMD ["java", "-jar", "app.jar"]
