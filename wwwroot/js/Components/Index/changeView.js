"use strict";
class ChangeView {
    constructor() {
        this.Change = (e) => {
            var _a;
            const target = e.target;
            const data = target.dataset.window;
            const windows = document.querySelectorAll(".join__data");
            console.log("a");
            for (const window of windows) {
                window.classList.remove("show");
                if (window.dataset.window == data)
                    window.classList.add("show");
            }
            (_a = document.querySelector(".join__item.active")) === null || _a === void 0 ? void 0 : _a.classList.remove("active");
            target.classList.add("active");
        };
        document.querySelectorAll(".join__item").forEach(el => el.addEventListener("click", this.Change));
    }
}
const changeView = new ChangeView();
//# sourceMappingURL=changeView.js.map