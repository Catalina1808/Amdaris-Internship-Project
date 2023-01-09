class Book {
    id: number;
    title:string;
    author:string;
    image:string;

    constructor(id:number, title:string, author:string, image:string){
        this.id = id;
        this.author = author;
        this.title = title;
        this.image = image;
    }

}
export type BookType = {
    id: number;
    title:string;
    author:string;
    image:string;
}
