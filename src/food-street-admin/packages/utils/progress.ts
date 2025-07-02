import nprogrees from "NProgress";
import "NProgress/nprogress.css";
import eventEmitter from "./eventEmitter";

// 进度条
function start() {
  eventEmitter.on("progress:start", () => {
    nprogrees.start();
  });
}

function done() {
  eventEmitter.on("progress:finish", () => {
    nprogrees.done();
  });
}

start();
done();

export function useProgress() {
  start();
  done();
}
