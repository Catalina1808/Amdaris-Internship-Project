import { BookType } from "./book.model";

export type AuthorType = {
    id: number;
    name:string;
    image: string;
    description:string;
    books: BookType[];
}