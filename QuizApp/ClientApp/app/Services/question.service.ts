import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Question } from '../models/question.interface';
//import { ConfigService } from '../utils/config.service';

import { BaseService } from "./base.service";

import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/Rx';

@Injectable()
export class QuestionService extends BaseService {
    baseUrl: string = '';
    constructor(private http: Http) {
        super();
    }

    addQuestion(questiontype: string, subject: string, questiontext: string, options1: string[], difficulty: string): Observable<Question> {
        let body = JSON.stringify({ questiontype, subject, questiontext, options1, difficulty });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post(this.baseUrl + "api/Questions", body, options)
            .map(res => true)
            .catch(this.handleError);
    }
}