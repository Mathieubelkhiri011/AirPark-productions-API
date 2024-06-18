FROM eclipse-temurin:22-jdk as build
COPY . /app
WORKDIR /app
RUN ./mvnw package -DskipTests
RUN mv -f target/*.jar app.jar
