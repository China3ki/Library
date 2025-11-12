import { SearchEngine } from "./search.js";
export class Header {
    constructor() {
        this.searchEnigne = new SearchEngine(this);
        this.HideHeaderNav = (e) => {
            const header = document.querySelector(".header");
            if (header != null) {
                if (e.deltaY > 0)
                    header.classList.add("active");
                else if (e.deltaY < 0)
                    header.classList.remove("active");
            }
        };
        this.RemoveListener = () => {
            window.removeEventListener("wheel", this.HideHeaderNav);
        };
        this.AddListener = () => {
            window.addEventListener("wheel", this.HideHeaderNav);
        };
        window.addEventListener("wheel", this.HideHeaderNav);
    }
}
const header = new Header();
//# sourceMappingURL=header.js.map