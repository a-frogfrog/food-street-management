import {eventEmitter} from "@frog/utils";
import router from "..";
//路由事件

// 监听网络断开事件 并跳转到错误页面
eventEmitter.on("network:offline", () => {
  console.log("网络断开");
  router.push("/error/network");
});

eventEmitter.on("api:unauthorized", () => {
  console.log("unauthorized");
  router.push("/auth/login");
});
