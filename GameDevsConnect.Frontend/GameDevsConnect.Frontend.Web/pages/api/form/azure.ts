import type { NextApiRequest, NextApiResponse } from "next";
import { getAxiosInstance } from "@/lib/axios_config";
import formidable from 'formidable';
import fs from 'fs';

export const config = {
  api: {
    bodyParser: false,
    sizeLimit: '200mb',
  },
};

function parseForm(req: NextApiRequest): Promise<{ fields: formidable.Fields; files: formidable.Files }> {
  const form = formidable({ maxFileSize: 200 * 1024 * 1024, uploadDir: './uploads', keepExtensions: true });

  return new Promise((resolve, reject) => {
    form.parse(req, (err, fields, files) => {
      if (err) reject(err);
      else resolve({ fields, files });
    });
  });
}

export default async function handler(req: NextApiRequest, res: NextApiResponse) 
{
  try 
  {
    let url = `${process.env.BACKEND_URL}/api/v1/azure/blob/upload`
    const { fields, files } = await parseForm(req);

    const requestJson = JSON.parse((fields.request as string[])[0]);
    const file = Array.isArray(files.file) ? files.file[0] : files.file;

    if(!file?.filepath)
      return res.status(500);

    const fileStream = fs.createReadStream(file.filepath);

    const response = await (await getAxiosInstance()).postForm(url, {
      FormFile: fileStream,
      Request: JSON.stringify(requestJson),
    }).then(r => r.data);

    fs.unlink(file.filepath, () =>{})

    return res.status(200).json(response);
  } 
  catch (err) 
  {
    console.error('Fehler beim Upload:', err);
    return res.status(500).json({ error: 'Fehler beim Upload', detail: (err as Error).message });
  }
}