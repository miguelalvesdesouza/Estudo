import { fastify } from "fastify";
import { DatabaseMemory } from "./database-memory.js";

const server = fastify();

const database = new DatabaseMemory();

server.post("/videos", (request, reply) => {
  const { title, descriptio, duration } = request.body;
  database.create({
    title,
    descriptio,
    duration,
  });

  return reply.status(201).send();
});

server.get("/videos", (request, reply) => {
  const videos = database.list();

  return videos;
});

server.put("/videos/:id", () => {
  return "hello";
});

server.delete("/videos/:id", () => {
  return "hello";
});

server.listen({
  port: 3333,
});
