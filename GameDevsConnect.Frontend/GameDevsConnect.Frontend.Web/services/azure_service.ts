import { getUrl } from "@/lib/api"
import axios from "axios"
const url = getUrl('form','azure/blob')

// Wichtig, FileName und ContainerName < Groß als Json {} Request

// Upload von Dateien im Format UserId/FileName ohne Endung, FileName ist die File ID

export const uploadFile = async (file:File, request:string) =>
{
    return await axios.postForm('https://localhost:3000/api/form/azure', {file, request}).then(x => x.data);
}