# Use the official MySQL image as the base image
FROM mysql:latest

# Set environment variables (replace with your values)
ENV MYSQL_ROOT_PASSWORD=pwd
ENV MYSQL_DATABASE=db
ENV MYSQL_ALLOW_EMPTY_PASSWORD=1

# Expose the MySQL port (optional, but may be needed for external access)
EXPOSE 3306
