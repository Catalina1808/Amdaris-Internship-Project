import { AuthorType } from "./author.model";

export type BookType = {
    id: number;
    title:string;
    authors:AuthorType[];
    image:string;
    description: string;
    rating: number;
}