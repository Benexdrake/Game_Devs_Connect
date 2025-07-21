import { url } from "@/lib/api"

const getUrl = url('get','azure')
const postUrl = url('post','azure')
const putUrl = url('put','azure')
const deleteUrl = url('delete','azure')

// Wichtig, FileName und ContainerName < Groß als Json {} Request

// Upload von Dateien im Format UserId/FileName ohne Endung, FileName ist die File ID