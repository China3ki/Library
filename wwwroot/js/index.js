"use strict";
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
//# sourceMappingURL=index.js.map