import { Component } from '@angular/core';

@Component({
  selector: 'app-wave',
  templateUrl: './comp1.component.html',
  styleUrls: ['./comp1.component.css']
})
export class Comp1Component {
  private _waveFrms : Array<string> = [
    "___________________________________",
    "▂_________________________________",
    "▃▂_______________________________",
    "▄▃▂______________________________",
    "▅▄▃▂____________________________",
    "▆▅▄▃▂__________________________",
    "▇▆▅▄▃▂________________________",
    "█▇▆▅▄▃▂_______________________",
    "▇█▇▆▅▄▃▂_____________________",
    "▆▇█▇▆▅▄▃▂___________________",
    "▅▆▇█▇▆▅▄▃▂_________________",
    "▄▅▆▇█▇▆▅▄▃▂________________",
    "▃▄▅▆▇█▇▆▅▄▃▂______________",
    "▂▃▄▅▆▇█▇▆▅▄▃▂____________",
    "__▂▃▄▅▆▇█▇▆▅▄▃▂__________",
    "___▂▃▄▅▆▇█▇▆▅▄▃▂_________",
    "____▂▃▄▅▆▇█▇▆▅▄▃▂________",
    "_____▂▃▄▅▆▇█▇▆▅▄▃▂_______",
    "______▂▃▄▅▆▇█▇▆▅▄▃▂______",
    "_______▂▃▄▅▆▇█▇▆▅▄▃▂_____",
    "________▂▃▄▅▆▇█▇▆▅▄▃▂____",
    "_________▂▃▄▅▆▇█▇▆▅▄▃▂___",
    "__________▂▃▄▅▆▇█▇▆▅▄▃▂__",
    "___________▂▃▄▅▆▇█▇▆▅▄▃▂_",
    "_____________▂▃▄▅▆▇█▇▆▅▄▃▂",
    "_______________▂▃▄▅▆▇█▇▆▅▄▃",
    "_________________▂▃▄▅▆▇█▇▆▅▄",
    "__________________▂▃▄▅▆▇█▇▆▅",
    "____________________▂▃▄▅▆▇█▇▆",
    "______________________▂▃▄▅▆▇█▇",
    "________________________▂▃▄▅▆▇█",
    "_________________________▂▃▄▅▆▇",
    "___________________________▂▃▄▅▆",
    "_____________________________▂▃▄▅",
    "_______________________________▂▃▄",
    "_______________________________▂▃",
    "_________________________________▂",
    "___________________________________",
    "___________________________________",
    "___________________________________",
  ];
  private _counter : number = 0;
  private get counter() : number {
    if (this._counter >= this._waveFrms.length)
      this._counter = 0;
    return this._counter++;
  }

  public WaveFrame : string = this._waveFrms[0];

  public UpdateWaveFrame() {
    this.WaveFrame = this._waveFrms[this.counter];
  }
}