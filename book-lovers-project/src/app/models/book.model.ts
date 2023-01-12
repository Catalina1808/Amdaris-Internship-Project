import { AuthorType } from "./author.model";
import { ReviewType } from "./review.model";

export type BookType = {
    id: number;
    title:string;
    authors:AuthorType[];
    reviews:ReviewType[];
    image:string;
    description: string;
}