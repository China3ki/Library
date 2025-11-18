class SortData {
    
    constructor() {
        document.querySelectorAll("[data-sort]").forEach(el => el.addEventListener("click", this.Sort))
    }
    Sort = async (e: Event) => {
        const target = e.currentTarget as HTMLElement;
        const sortType = target.dataset.sorttype;
        const sortBy = target.dataset.sort
        if (sortBy == undefined || sortType == undefined) return;
        target.dataset.sorttype = sortType == SortType.Asc ? SortType.Desc : SortType.Asc;
        const data = await this.GetData(sortBy, sortType)
        if (data == null) return;
        this.RenderData(data);
    }
    GetData = async (sortBy: string, sortType: string) : Promise<Book[] | null | undefined> => {
        const asc: boolean = sortType == "Asc" ? false : true;
        const page: number | undefined = parseInt(this.GetPage());
        const calcStart: number = (page - 1) * 10;

        const fetchData: Response = await fetch(`https://localhost:7051/api/Books?start=${calcStart}&sortBy=${sortBy}&limit=10&desc=${asc}`);
        if (fetchData.ok) return await fetchData.json();
        else return null;
    }
    GetPage = () : string  => {
        const params: URLSearchParams = new URLSearchParams(window.location.search);
        const page = params.get("page");
        if (page == null) throw new Error("Page variable does not exist!");
        return page;
    }
    RenderData = async (data : Book[]) => {
        const table: HTMLTableElement | null = document.querySelector(".table");
        if (table == null) return;
        this.RemoveRows();
        for (let i = 1; i < data.length + 1; i++) {
            const row = table.insertRow(i);
            const cell1 = row.insertCell(0)
            const cell2 = row.insertCell(1)
            const cell3 = row.insertCell(2)
            const cell4 = row.insertCell(3)
            const cell5 = row.insertCell(4)
            const cell6 = row.insertCell(5)
            cell1.innerText = `${data[i - 1].bookId}`;
            cell2.innerText = data[i - 1].bookTitle;
            cell3.innerText = data[i - 1].categoryName;
            cell4.innerText = `${data[i - 1].authorName} ${data[i - 1].authorSurname}`;
            cell5.innerText = `${data[i - 1].bookReleaseDate}`;
            cell6.classList.add("table__cell");
            cell6.innerHTML =`<a href="/Books/Edit?bookId=${data[i - 1].bookId}">Edit</a>`

        }
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
const sortData: SortData = new SortData();
enum SortType {
    Asc = "Asc",
    Desc = "Desc"
}
interface Book {
    bookId: Number,
    bookTitle: string,
    authorName: string,
    authorSurname: string,
    categoryName: string,
    bookReleaseDate: number,
}