import { SearchEngine } from "./search.js"
export class Header {
    constructor() {
        window.addEventListener("wheel", this.HideHeaderNav);
    }
    searchEnigne: SearchEngine = new SearchEngine(this);
    HideHeaderNav = (e: WheelEvent) => {
        const header: HTMLElement | null = document.querySelector(".header");
        if (header != null) {
            if (e.deltaY > 0) header.classList.add("active");
            else if (e.deltaY < 0) header.classList.remove("active");
        }
    };
    RemoveListener = () => {
        window.removeEventListener("wheel", this.HideHeaderNav);
    }
    AddListener = () => {
        window.addEventListener("wheel", this.HideHeaderNav);
    }
}
const header: Header = new Header();