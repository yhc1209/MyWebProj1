import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

interface TheMember {
  id: number;
  name: string;
  age: number;
  gender: number;
  remark: string;
}
interface GetMemberRsp {
  name: string;
  action: string;
  code: number;
  message: string;
  objects: TheMember[];
}

class GetMemberReq {
  name: string;
  action: string;
  objects: ClientInfo[];

  constructor(clnInfo: ClientInfo) {
    this.name = "TheMemberService";
    this.action = "getMembers";
    this.objects = [ clnInfo ];
  }
}
class ClientInfo {
  machineName: string;
  account: string;
  pwHash: string;

  constructor() {
    this.machineName = "yhc's computer";
    this.account = "yhc";
    this.pwHash = "i20sdzfk32sg4302iejslg2";
  }
}

const CONST_MEMBER_DATA: TheMember[] = [
  { id: 0, name: "Jack Jerk", age: 33, gender: 1, remark: "normal person." },
  { id: 1, name: "Leo Loner", age: 30, gender: 1, remark: "mental issue." },
  { id: 2, name: "Wendy Windy", age: 22, gender: 2, remark: "premature." },
  { id: 3, name: "Sunny Shopee", age: 24, gender: 1, remark: "" },
  { id: 5, name: "Sally Silly", age: 16, gender: 0, remark: "nobody knows where is it from." },
];

@Component({
  selector: 'app-dbtest',
  templateUrl: './dbtest.component.html',
  styleUrls: ['./dbtest.component.css']
})
export class DBtestComponent {
  private dataSource: TheMember[] = [];
  private hostUrl: string = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.hostUrl = baseUrl;
    console.log(this.hostUrl);
  }

  public readonly DisplayedColumns: string[] = ['identifier', 'name', 'gender', 'age', 'remark'];
  public get DataSource(): TheMember[] {
    return this.dataSource;
  }

  public GenderString(i: number): string {
    if (i == 1)
      return "男性";
    else if (i == 2)
      return "女性";
    else
      return "不清楚";
  }
  public GetSampleDataFromTs(): void {
    this.dataSource = CONST_MEMBER_DATA;
  }
  public GetSampleDataFromCs(): void {
    this.http.get<TheMember[]>(this.hostUrl + "api/member/sample").subscribe(
      res => {
        this.dataSource = res;
      },
      err => {
        this.dataSource = [];
        console.log(err);
      }
    )
  }
  public GetDataFromCs(): void {
    let clnInfo: ClientInfo = new ClientInfo();
    let req: GetMemberReq = new GetMemberReq(clnInfo);
    console.log(req);
    this.http.post<GetMemberRsp>(this.hostUrl + "api/member/getMembers", req).subscribe(
      res => {
        if (res.code == 0)
          this.dataSource = res.objects;
        else
        {
          this.dataSource = [];
          console.warn(`error code: ${res.code}`);
          console.warn(`message: ${res.message}`);
        }
      },
      err => {
        this.dataSource = [];
        console.log(err);
      }
    )
  }
  public AddMember(data: TheMember) {
    // alert(
    //   "你要註冊成員：" +
    //   "\n名字：" + data.name +
    //   "\n性別：" + this.GenderString(data.gender) +
    //   "\n年齡：" + data.age +
    //   "\n註記：" + data.remark
    // );
  }
}
