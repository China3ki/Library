export class SortData {
    constructor() {
        this.GetSortOptions = (target) => {
            const sortType = target.dataset.sorttype;
            const sortBy = target.dataset.sort;
            if (sortBy == undefined || sortType == undefined)
                return;
            target.dataset.sorttype = sortType == SortType.Asc ? SortType.Desc : SortType.Asc;
            return [sortBy, sortType];
        };
        this.GetPage = () => {
            const params = new URLSearchParams(window.location.search);
            const page = params.get("page");
            if (page == null)
                throw new Error("Page variable does not exist!");
            return page;
        };
        this.RemoveRows = () => {
            const rows = document.querySelectorAll("tr");
            if (rows == null)
                return;
            for (let i = 0; i < rows.length; i++) {
                if (i == 0)
                    continue;
                rows[i].remove();
            }
        };
    }
}
var SortType;
(function (SortType) {
    SortType["Asc"] = "Asc";
    SortType["Desc"] = "Desc";
})(SortType || (SortType = {}));
//# sourceMappingURL=sorting.js.map