import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/Http';
import { SocialMediaMessage } from '../models/socialMediaMessage';
import { SocialMediaSearch } from '../models/socialMediaSearch';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/throw';

@Injectable()
export class SocialMediaService {
    private socialMediaApiUrl = 'http://localhost:63844';
    private twitterEndpoint = '/twitter';
    private searchesEndpoint = '/searches';

    constructor(private http: Http) {
    }

    public getTwitterMessages(tag: string): Observable<SocialMediaMessage[]> {
        return this.http.get(this.socialMediaApiUrl + this.twitterEndpoint + '/' + encodeURIComponent(tag))
            .map(res => res.json())
            .catch(this._serverError);
    }

    public getAllSearches(): Observable<SocialMediaSearch[]> {
        return this.http.get(this.socialMediaApiUrl + this.searchesEndpoint)
            .map(res => res.json())
            .catch(this._serverError);
    }

    private _serverError(err: any) {
        console.log('Social Media API Error:', err);
        return Observable.throw('Social Media API Error');
    }
}
