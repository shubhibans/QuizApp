import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { AccountFormComponent } from './components/account-form/account-form.component';
import { UserServiceService } from "./Services/user-service.service";
import { LoginPageComponent } from './components/login-page/login-page.component';
import { QuestionPageComponent } from './components/question-page/question-page.component';
import { QuestionService } from "./Services/question.service";

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        AccountFormComponent,
        LoginPageComponent,
        QuestionPageComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'account', component: AccountFormComponent },
            { path: 'add-Question', component: QuestionPageComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'login', component: LoginPageComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers:[UserServiceService, QuestionService]
})
export class AppModuleShared {
}
