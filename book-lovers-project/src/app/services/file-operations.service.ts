import { HttpClient, HttpResponse, HttpResponseBase } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileOperationsService {
  constructor(private httpClient: HttpClient) { }

  uploadPhoto(file: File): Observable<any> {
    // Create form data
    let formData = new FormData();

    // Store form name as "file" with file data
    formData.append('files', file, file.name);

    return this.httpClient.post('/api/File/UploadFile', formData, {observe:'response', responseType:'text'});
  }

  deletePhoto(fileName: string): Observable<{}> {
    return this.httpClient.delete(`/api/File/DeleteFile?fileName=${fileName}`);
  }
}
