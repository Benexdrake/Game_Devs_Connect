import { TagType } from "./tag";
import { UserType } from "./user";

export type RequestType =
{
    id:number;
    title:string;
    description:string;
    fileId:number;
    created:string;
    projectId:string;
    ownerId:string;
}

export type RequestBlockType =
{
    request:RequestType;
    tags:TagType[];
    user:UserType;
    count:number
    likes:number;
}