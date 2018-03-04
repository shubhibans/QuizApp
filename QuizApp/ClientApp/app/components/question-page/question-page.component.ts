import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Question } from '../../Models/question.interface';
import { QuestionService } from "../../Services/question.service";

@Component({
    selector: 'app-question-page',
    templateUrl: './question-page.component.html',
    styleUrls: ['./question-page.component.css']
})
export class QuestionPageComponent implements OnInit {
    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;

    constructor(private questionservice: QuestionService, private router: Router) { }

    ngOnInit() {
    }
    addQuestion({ value, valid }: { value: Question, valid: boolean }) {
        this.submitted = true;
        this.isRequesting = true;
        let list: string[] = [value.option1, value.option2, value.option3, value.option4, value.option5, value.option6];
        this.errors = '';
        if (valid) {
            this.questionservice.addQuestion(value.questiontype, value.subject, value.questiontext, list, value.difficulty)
                .finally(() => this.isRequesting = false)
                .subscribe(
                result => {
                    if (result) {
                        this.router.navigate(['/'], { queryParams: { brandNew: true, email: value.questiontype } });
                    }
                },
                errors => this.errors = errors);
        }

    }
}