"use strict";
var _a, _b;
let lastScroll = 0;
const HideHeaderNav = (e) => {
    const header = document.querySelector(".header");
    if (header != null) {
        if (e.deltaY > 0)
            header.classList.add("active");
        else if (e.deltaY < 0)
            header.classList.remove("active");
    }
};
let index = 1;
const RightReview = (e) => {
    const reviewsHTML = document.querySelectorAll(".join__review");
    const leftArrow = document.querySelector(".join__button--left");
    if (leftArrow != null)
        leftArrow.classList.remove("hide");
    if (index == reviewsHTML.length - 1)
        return;
    reviewsHTML[index].classList.remove("show");
    reviewsHTML[index].classList.add("left");
    reviewsHTML[index + 1].classList.remove("right");
    reviewsHTML[index + 1].classList.add("show");
    if (index - 1 != -1)
        reviewsHTML[index - 1].classList.remove("left");
    if (index + 2 != reviewsHTML.length)
        reviewsHTML[index + 2].classList.add("right");
    index++;
    if (index == reviewsHTML.length - 1) {
        const rightArrow = e.target;
        rightArrow.classList.add("hide");
    }
};
const LeftReview = (e) => {
    const reviewsHTML = document.querySelectorAll(".join__review");
    const rightArrow = document.querySelector(".join__button--right");
    if (rightArrow != null)
        rightArrow.classList.remove("hide");
    if (index == 0)
        return;
    reviewsHTML[index].classList.remove("show");
    reviewsHTML[index].classList.add("right");
    reviewsHTML[index - 1].classList.remove("left");
    reviewsHTML[index - 1].classList.add("show");
    if (index + 1 != reviewsHTML.length)
        reviewsHTML[index + 1].classList.remove("right");
    if (index - 2 != -1)
        reviewsHTML[index - 2].classList.add("left");
    index--;
    if (index == 0) {
        const leftArrow = e.target;
        leftArrow.classList.add("hide");
    }
};
const ChangeWindow = (e) => {
    var _a;
    const target = e.target;
    const data = target.dataset.window;
    const windows = document.querySelectorAll(".join__data");
    for (const window of windows) {
        window.classList.remove("show");
        if (window.dataset.window == data)
            window.classList.add("show");
    }
    (_a = document.querySelector(".join__item.active")) === null || _a === void 0 ? void 0 : _a.classList.remove("active");
    target.classList.add("active");
};
(_a = document.querySelector('.join__button--left')) === null || _a === void 0 ? void 0 : _a.addEventListener("click", LeftReview);
(_b = document.querySelector('.join__button--right')) === null || _b === void 0 ? void 0 : _b.addEventListener("click", RightReview);
document.querySelectorAll(".join__item").forEach(el => el.addEventListener("click", ChangeWindow));
//# sourceMappingURL=index.js.map