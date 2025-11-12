"use strict";
class Reviews {
    constructor() {
        var _a, _b;
        this.index = 1;
        this.RightReview = (e) => {
            const reviewsHTML = document.querySelectorAll(".join__review");
            const leftArrow = document.querySelector(".join__button--left");
            if (leftArrow != null)
                leftArrow.classList.remove("hide");
            if (this.index == reviewsHTML.length - 1)
                return;
            reviewsHTML[this.index].classList.remove("show");
            reviewsHTML[this.index].classList.add("left");
            reviewsHTML[this.index + 1].classList.remove("right");
            reviewsHTML[this.index + 1].classList.add("show");
            if (this.index - 1 != -1)
                reviewsHTML[this.index - 1].classList.remove("left");
            if (this.index + 2 != reviewsHTML.length)
                reviewsHTML[this.index + 2].classList.add("right");
            this.index++;
            if (this.index == reviewsHTML.length - 1) {
                const rightArrow = e.target;
                rightArrow.classList.add("hide");
            }
        };
        this.LeftReview = (e) => {
            const reviewsHTML = document.querySelectorAll(".join__review");
            const rightArrow = document.querySelector(".join__button--right");
            if (rightArrow != null)
                rightArrow.classList.remove("hide");
            if (this.index == 0)
                return;
            reviewsHTML[this.index].classList.remove("show");
            reviewsHTML[this.index].classList.add("right");
            reviewsHTML[this.index - 1].classList.remove("left");
            reviewsHTML[this.index - 1].classList.add("show");
            if (this.index + 1 != reviewsHTML.length)
                reviewsHTML[this.index + 1].classList.remove("right");
            if (this.index - 2 != -1)
                reviewsHTML[this.index - 2].classList.add("left");
            this.index--;
            if (this.index == 0) {
                const leftArrow = e.target;
                leftArrow.classList.add("hide");
            }
        };
        (_a = document.querySelector('.join__button--left')) === null || _a === void 0 ? void 0 : _a.addEventListener("click", this.LeftReview);
        (_b = document.querySelector('.join__button--right')) === null || _b === void 0 ? void 0 : _b.addEventListener("click", this.RightReview);
    }
}
const review = new Reviews();
//# sourceMappingURL=reviews.js.map