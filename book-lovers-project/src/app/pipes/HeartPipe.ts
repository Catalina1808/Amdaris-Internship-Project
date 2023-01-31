import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: "heart"
})
export class HeartPipe implements PipeTransform{
    transform(value: any, ...args: any[]) {
        return value + " <3";
    }
}