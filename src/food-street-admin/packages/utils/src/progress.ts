import progress from "NProgress";
import "NProgress/nprogress.css";
import { eventEmitter } from "@frog/event";

// 进度条
function start() {
  eventEmitter.on("progress:start", () => {
    progress.start();
  });
}

function done() {
  eventEmitter.on("progress:finish", () => {
    progress.done();
  });
}

start();
done();

export function useProgress() {
  start();
  done();
}
