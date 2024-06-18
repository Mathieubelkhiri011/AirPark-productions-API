# Etape 1 : Build
FROM maven:3.8.5-openjdk-17-slim AS build

# Définir le répertoire de travail
WORKDIR /app

# Copier le projet dans le conteneur
COPY . .

# Compiler le projet et créer le fichier JAR
RUN mvn clean package -DskipTests

# Etape 2 : Run
FROM openjdk:17-jdk-slim

# Définir le répertoire de travail
WORKDIR /app

# Copier le fichier JAR de l'étape de build
COPY --from=build /app/target/*.jar app.jar

# Exposer le port 8080
EXPOSE 8080

# Définir la commande de démarrage
CMD ["java", "-jar", "app.jar"]
