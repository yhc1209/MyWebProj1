import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RouterLink, RouterModule } from '@angular/router';

@Component({
  selector: 'app-todo-page',
  templateUrl: './todo-page.component.html',
  styleUrls: ['./todo-page.component.css'],
})
export class TodoPageComponent {
  
  constructor(private _http : HttpClient) {}
  
  public hint() : void {
    alert("彈出！");
  }

  // ------ 進度條測試 ------
  private _progress : number = 0;
  public get Progress() : number {
    return this._progress;
  }
  public work4progress() : void {
    if (this._progress < 100)
      this._progress += 20;
    else
    {
      alert("完成！");
      this._progress = 0;
    }
  }

  // ------ 查字典API ------
  private _fetchResult!: DictResult;
  public get FetchResult() : DictResult {
    return this._fetchResult;
  }
  public theWord : string = "";
  public showResult : boolean = false;
  public fetchData() : void {
    if (this.theWord.length == 0)
    {
      console.log("啥也不是，散會！");
      this.showResult = false;
      return;
    }
    console.log(`要查的字：${this.theWord}`);
    this._http.get<DictResult>("https://www.moedict.tw/uni/" + this.theWord).subscribe(
      result => {
        this._fetchResult = result;
        this.showResult = true;
      },
      error => {
        this.showResult = false;
        console.error(error);
      }
    );
  }
  public reset() : void {
    this.theWord = "";
    this.showResult = false;
  }

  // ------ form測試 ------
  public submitForm1(form : any) : void {
    console.log("form data:");
    console.log(form);
  }
}

// ---------------------------------------------------------------
interface Definition {
  def : string;
  type : string;
  example : Array<string>;
  quote : Array<string>;
  synonyms : string;
  antonyms : string;
}

interface Heteronym {
    bopomofo : string;
    bopomofo2 : string;
    definitions : Array<Definition>;
    pinyin : string;
}

interface DictResult {
    heteronyms : Array<Heteronym>;
    non_radical_stroke_count : number;
    radical : string;
    stroke_count : number;
    title : string;
}
