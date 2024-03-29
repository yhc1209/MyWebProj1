// requset
export class ProtocolBase {
    name: string;
    action: string;
    constructor(act: string) {
        this.name = "TheMemberService";
        this.action = act;
    }
}

export class GetMemberReq extends ProtocolBase {
    objects: ClientInfo[];
    constructor() {
        super("getMembers");
        this.objects = [ new ClientInfo() ];
    }
}
export class NewMemberReq extends ProtocolBase {
    objects: MO_NewMember[];
    constructor(m: TheMember) {
        super("newMember");
        this.objects = [ new MO_NewMember(m) ];
    }
}

// response
export interface GetMemberRsp {
    name: string;
    action: string;
    code: number;
    message: string;
    objects: TheMember[];
}
export interface NewMemberRsp {
    name: string;
    action: string;
    code: number;
    message: string;
    objects: object[];
}

// ---------------- base ----------------
export class MO_NewMember {
    info: ClientInfo;
    member: TheMember;
    constructor(m: TheMember) {
        this.member = m;
        this.info = new ClientInfo();
    }
}
export class ClientInfo {
    machineName: string;
    account: string;
    pwHash: string;
    
    constructor() {
        this.machineName = "yhc's computer";
        this.account = "yhc";
        this.pwHash = "i+q20sdzfk32sgFe3W02iejslg2=";
    }
}

export class TheMember {
    id: number = -1;
    name: string = "";
    age: number = 0;
    gender: number = 0;
    remark: string = "";
}