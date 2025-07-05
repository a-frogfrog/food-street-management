/**
 * 全屏功能
 * @returns {requestFullScreen: Function, exitFullScreen: Function}
 */
export function useFullScreen() {
  function requestFullScreen(element: any) {
    openScreen && element[openScreen]();
  }

  function exitFullScreen() {
    closeScreen;
  }

  return {
    requestFullScreen,
    exitFullScreen,
  };
}

const fullScreenNames = [
  "requestFullscreen",
  "mozRequestFullScreen",
  "webkitRequestFullscreen",
  "msRequestFullscreen",
];

const exitFullScreenNames = [
  "exitFullscreen",
  "mozCancelFullScreen",
  "webkitExitFullscreen",
  "msExitFullscreen",
];

const openScreen = getFullScreenElement(fullScreenNames, document);
const closeScreen = getFullScreenElement(exitFullScreenNames, document);

function getFullScreenElement(names: any[], target: any) {
  return names.find((name) => name in target);
}
