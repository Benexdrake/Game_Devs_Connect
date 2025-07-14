import { ITag } from "@/interfaces/tag";

export const getTagsByType = (type:string, tags:ITag[]) =>
{
    return tags.filter(x => x.type === type);
}