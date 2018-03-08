import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-generate-quiz',
  templateUrl: './generate-quiz.component.html',
  styleUrls: ['./generate-quiz.component.css']
})
export class GenerateQuizComponent implements OnInit {
    rows = [1];
    show: boolean;
    

    constructor()
    {
        this.show = false;
    }
    public AddRow()
    {
        var num2 = this.rows.length+1;
        this.rows.push(num2);
       
    }

    public DeleteRow()
    {
        if (this.rows.length != 1) {
            var lastnum = this.rows.length - 1;
            this.rows.splice(lastnum);
            
        }
       
    }

    public showDelete()
    {
        if (this.rows.length != 1)
        {
            return false;
        }
        else return true;
    }

  ngOnInit() {
  }

}
