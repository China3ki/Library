export class SortData {
    
    GetSortOptions = (target : HTMLElement) => {
        const sortType = target.dataset.sorttype;
        const sortBy = target.dataset.sort
        if (sortBy == undefined || sortType == undefined) return;
        target.dataset.sorttype = sortType == SortType.Asc ? SortType.Desc : SortType.Asc;
        return [sortBy, sortType];
    }
    GetPage = () : string  => {
        const params: URLSearchParams = new URLSearchParams(window.location.search);
        const page = params.get("page");
        if (page == null) throw new Error("Page variable does not exist!");
        return page;
    }

    RemoveRows = () => {
        const rows: NodeListOf<HTMLElement> | null = document.querySelectorAll("tr");
        if (rows == null) return;
        for (let i = 0; i < rows.length; i++) {
            if (i == 0) continue;
            rows[i].remove();
        }
    }
}
enum SortType {
    Asc = "Asc",
    Desc = "Desc"
}
