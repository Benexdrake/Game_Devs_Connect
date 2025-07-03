export interface IPost
{
    id:string;
    parentId:string | null;
    hasQuest:boolean;
    message:string;
    created:string;
    projectId:string;
    ownerId:string;
    fileId:string;
    isDeleted:boolean;
    completed:boolean;
}