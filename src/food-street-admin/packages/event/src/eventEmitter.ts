type EventMap = {
  "api:unauthorized": [];
  "progress:start": [];
  "progress:finish": [];
  "network:offline": [];
};

class EventEmitter<Events extends Record<string, any[]>> {
  private _listeners: {
    [K in keyof Events]?: Set<(...args: Events[K]) => void>;
  } = {};

  on<K extends keyof Events>(event: K, callback: (...args: Events[K]) => void) {
    if (!this._listeners[event]) {
      this._listeners[event] = new Set();
    }
    this._listeners[event].add(callback);
  }

  emit<K extends keyof Events>(event: K, ...args: Events[K]) {
    if (this._listeners[event]) {
      this._listeners[event].forEach((callback) => callback(...args));
    }
  }

  off<K extends keyof Events>(
    event: K,
    callback: (...args: Events[K]) => void,
  ) {
    if (this._listeners[event]) {
      this._listeners[event].delete(callback);
    }
  }
}

export default new EventEmitter<EventMap>();
