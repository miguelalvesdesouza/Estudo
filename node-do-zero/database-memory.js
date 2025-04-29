import { randomUUID } from "node:crypto";

export class DatabaseMemory {
  //chave privada visível apenas dentro dessa classe
  #videos = new Map(); //Map() é uma coleção de pares chave-valor

  list() {
    return Array.from(this.#videos.values());
  }

  create(video) {
    const videoId = randomUUID(); //criação de um id unico

    this.#videos.set(videoId, video);
  }

  update(id, video) {
    this.#videos.set(id, video);
  }

  delete(id) {
    this.#videos.delete(id);
  }
}
