//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v14.1.0.0 (NJsonSchema v11.0.2.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable()
export class NpcClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ?? "";
    }

    getAll(sortDirection: SortDirection | undefined, sortProperty: SortProperty | undefined, pageIndex: number | undefined, pageSize: number | undefined): Observable<GetNpcTemplatesQueryResult> {
        let url_ = this.baseUrl + "/api/npc/gettemplates?";
        if (sortDirection === null)
            throw new Error("The parameter 'sortDirection' cannot be null.");
        else if (sortDirection !== undefined)
            url_ += "sortDirection=" + encodeURIComponent("" + sortDirection) + "&";
        if (sortProperty === null)
            throw new Error("The parameter 'sortProperty' cannot be null.");
        else if (sortProperty !== undefined)
            url_ += "sortProperty=" + encodeURIComponent("" + sortProperty) + "&";
        if (pageIndex === null)
            throw new Error("The parameter 'pageIndex' cannot be null.");
        else if (pageIndex !== undefined)
            url_ += "pageIndex=" + encodeURIComponent("" + pageIndex) + "&";
        if (pageSize === null)
            throw new Error("The parameter 'pageSize' cannot be null.");
        else if (pageSize !== undefined)
            url_ += "pageSize=" + encodeURIComponent("" + pageSize) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetAll(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetAll(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<GetNpcTemplatesQueryResult>;
                }
            } else
                return _observableThrow(response_) as any as Observable<GetNpcTemplatesQueryResult>;
        }));
    }

    protected processGetAll(response: HttpResponseBase): Observable<GetNpcTemplatesQueryResult> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = GetNpcTemplatesQueryResult.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    get(id: number): Observable<Npc2> {
        let url_ = this.baseUrl + "/api/npc/gettemplate/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGet(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<Npc2>;
                }
            } else
                return _observableThrow(response_) as any as Observable<Npc2>;
        }));
    }

    protected processGet(response: HttpResponseBase): Observable<Npc2> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = Npc2.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status === 404) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result404: any = null;
            let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("A server side error occurred.", status, _responseText, _headers, result404);
            }));
        } else {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let resultdefault: any = null;
            let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            resultdefault = ProblemDetails.fromJS(resultDatadefault);
            return throwException("A server side error occurred.", status, _responseText, _headers, resultdefault);
            }));
        }
    }

    deleteTemplate(id: number): Observable<void> {
        let url_ = this.baseUrl + "/api/npc/deletetemplate/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
            })
        };

        return this.http.request("delete", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processDeleteTemplate(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDeleteTemplate(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<void>;
                }
            } else
                return _observableThrow(response_) as any as Observable<void>;
        }));
    }

    protected processDeleteTemplate(response: HttpResponseBase): Observable<void> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return _observableOf(null as any);
            }));
        } else if (status === 404) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result404: any = null;
            let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("A server side error occurred.", status, _responseText, _headers, result404);
            }));
        } else if (status === 400) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result400: any = null;
            let resultData400 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result400 = ProblemDetails.fromJS(resultData400);
            return throwException("A server side error occurred.", status, _responseText, _headers, result400);
            }));
        } else {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let resultdefault: any = null;
            let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            resultdefault = ProblemDetails.fromJS(resultDatadefault);
            return throwException("A server side error occurred.", status, _responseText, _headers, resultdefault);
            }));
        }
    }
}

export class GetNpcTemplatesQueryResult implements IGetNpcTemplatesQueryResult {
    creatures!: Npc[];
    sortInformation!: SortInformationOfSortProperty;
    pageInformation!: PageInformation;

    constructor(data?: IGetNpcTemplatesQueryResult) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["creatures"])) {
                this.creatures = [] as any;
                for (let item of _data["creatures"])
                    this.creatures!.push(Npc.fromJS(item));
            }
            this.sortInformation = _data["sortInformation"] ? SortInformationOfSortProperty.fromJS(_data["sortInformation"]) : <any>undefined;
            this.pageInformation = _data["pageInformation"] ? PageInformation.fromJS(_data["pageInformation"]) : <any>undefined;
        }
    }

    static fromJS(data: any): GetNpcTemplatesQueryResult {
        data = typeof data === 'object' ? data : {};
        let result = new GetNpcTemplatesQueryResult();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.creatures)) {
            data["creatures"] = [];
            for (let item of this.creatures)
                data["creatures"].push(item.toJSON());
        }
        data["sortInformation"] = this.sortInformation ? this.sortInformation.toJSON() : <any>undefined;
        data["pageInformation"] = this.pageInformation ? this.pageInformation.toJSON() : <any>undefined;
        return data;
    }
}

export interface IGetNpcTemplatesQueryResult {
    creatures: Npc[];
    sortInformation: SortInformationOfSortProperty;
    pageInformation: PageInformation;
}

export class Npc implements INpc {
    id!: number;
    name!: string;
    strengthMax!: number;
    strengthMin!: number;
    vitalityMax!: number;
    vitalityMin!: number;
    bodyMax!: number;
    bodyMin!: number;
    agilityMax!: number;
    agilityMin!: number;
    dexterityMax!: number;
    dexterityMin!: number;
    intelligenceMax!: number;
    intelligenceMin!: number;
    willpowerMax!: number;
    willpowerMin!: number;
    emotionMax!: number;
    emotionMin!: number;
    karmaMax!: number;
    karmaMin!: number;
    hitPointMax!: number;
    hitPointMin!: number;
    manaMax!: number;
    manaMin!: number;
    powerPointMax!: number;
    powerPointMin!: number;
    difficulty!: Difficulty;
    race!: Race;

    constructor(data?: INpc) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.strengthMax = _data["strengthMax"];
            this.strengthMin = _data["strengthMin"];
            this.vitalityMax = _data["vitalityMax"];
            this.vitalityMin = _data["vitalityMin"];
            this.bodyMax = _data["bodyMax"];
            this.bodyMin = _data["bodyMin"];
            this.agilityMax = _data["agilityMax"];
            this.agilityMin = _data["agilityMin"];
            this.dexterityMax = _data["dexterityMax"];
            this.dexterityMin = _data["dexterityMin"];
            this.intelligenceMax = _data["intelligenceMax"];
            this.intelligenceMin = _data["intelligenceMin"];
            this.willpowerMax = _data["willpowerMax"];
            this.willpowerMin = _data["willpowerMin"];
            this.emotionMax = _data["emotionMax"];
            this.emotionMin = _data["emotionMin"];
            this.karmaMax = _data["karmaMax"];
            this.karmaMin = _data["karmaMin"];
            this.hitPointMax = _data["hitPointMax"];
            this.hitPointMin = _data["hitPointMin"];
            this.manaMax = _data["manaMax"];
            this.manaMin = _data["manaMin"];
            this.powerPointMax = _data["powerPointMax"];
            this.powerPointMin = _data["powerPointMin"];
            this.difficulty = _data["difficulty"];
            this.race = _data["race"];
        }
    }

    static fromJS(data: any): Npc {
        data = typeof data === 'object' ? data : {};
        let result = new Npc();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["strengthMax"] = this.strengthMax;
        data["strengthMin"] = this.strengthMin;
        data["vitalityMax"] = this.vitalityMax;
        data["vitalityMin"] = this.vitalityMin;
        data["bodyMax"] = this.bodyMax;
        data["bodyMin"] = this.bodyMin;
        data["agilityMax"] = this.agilityMax;
        data["agilityMin"] = this.agilityMin;
        data["dexterityMax"] = this.dexterityMax;
        data["dexterityMin"] = this.dexterityMin;
        data["intelligenceMax"] = this.intelligenceMax;
        data["intelligenceMin"] = this.intelligenceMin;
        data["willpowerMax"] = this.willpowerMax;
        data["willpowerMin"] = this.willpowerMin;
        data["emotionMax"] = this.emotionMax;
        data["emotionMin"] = this.emotionMin;
        data["karmaMax"] = this.karmaMax;
        data["karmaMin"] = this.karmaMin;
        data["hitPointMax"] = this.hitPointMax;
        data["hitPointMin"] = this.hitPointMin;
        data["manaMax"] = this.manaMax;
        data["manaMin"] = this.manaMin;
        data["powerPointMax"] = this.powerPointMax;
        data["powerPointMin"] = this.powerPointMin;
        data["difficulty"] = this.difficulty;
        data["race"] = this.race;
        return data;
    }
}

export interface INpc {
    id: number;
    name: string;
    strengthMax: number;
    strengthMin: number;
    vitalityMax: number;
    vitalityMin: number;
    bodyMax: number;
    bodyMin: number;
    agilityMax: number;
    agilityMin: number;
    dexterityMax: number;
    dexterityMin: number;
    intelligenceMax: number;
    intelligenceMin: number;
    willpowerMax: number;
    willpowerMin: number;
    emotionMax: number;
    emotionMin: number;
    karmaMax: number;
    karmaMin: number;
    hitPointMax: number;
    hitPointMin: number;
    manaMax: number;
    manaMin: number;
    powerPointMax: number;
    powerPointMin: number;
    difficulty: Difficulty;
    race: Race;
}

export enum Difficulty {
    Newbie = "Newbie",
    Novice = "Novice",
    Rookie = "Rookie",
    Beginner = "Beginner",
    Talented = "Talented",
    Skilled = "Skilled",
    Intermediate = "Intermediate",
    Skillful = "Skillful",
    Seasoned = "Seasoned",
    Proficient = "Proficient",
    Experienced = "Experienced",
    Advanced = "Advanced",
    Senior = "Senior",
    Expert = "Expert",
}

export enum Race {
    Goblin = "Goblin",
    CivilizedHuman = "CivilizedHuman",
    Barbarian = "Barbarian",
    AncientOrc = "AncientOrc",
    Orc = "Orc",
    HalfOrc = "HalfOrc",
    Elf = "Elf",
    DarkElf = "DarkElf",
    HalfElf = "HalfElf",
    HalfDarkElf = "HalfDarkElf",
    Dwarf = "Dwarf",
    Animal = "Animal",
    Bug = "Bug",
    Dragon = "Dragon",
    Mythical = "Mythical",
    CreatureOfDarkness = "CreatureOfDarkness",
    CreatureOfLight = "CreatureOfLight",
}

export class SortInformationOfSortProperty implements ISortInformationOfSortProperty {
    sortProperty!: SortProperty | undefined;
    sortDirection!: SortDirection | undefined;

    constructor(data?: ISortInformationOfSortProperty) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.sortProperty = _data["sortProperty"];
            this.sortDirection = _data["sortDirection"];
        }
    }

    static fromJS(data: any): SortInformationOfSortProperty {
        data = typeof data === 'object' ? data : {};
        let result = new SortInformationOfSortProperty();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["sortProperty"] = this.sortProperty;
        data["sortDirection"] = this.sortDirection;
        return data;
    }
}

export interface ISortInformationOfSortProperty {
    sortProperty: SortProperty | undefined;
    sortDirection: SortDirection | undefined;
}

export enum SortProperty {
    Vitality = "vitality",
    Body = "body",
    Agility = "agility",
    Dexterity = "dexterity",
    Intelligence = "intelligence",
    Willpower = "willpower",
    Emotion = "emotion",
    Karma = "karma",
    Strength = "strength",
    Race = "race",
    Name = "name",
    Id = "id",
}

export enum SortDirection {
    Asc = "asc",
    Desc = "desc",
}

export class PageInformation implements IPageInformation {
    totalCount!: number;
    pageSize!: number;
    pageIndex!: number;

    constructor(data?: IPageInformation) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.totalCount = _data["totalCount"];
            this.pageSize = _data["pageSize"];
            this.pageIndex = _data["pageIndex"];
        }
    }

    static fromJS(data: any): PageInformation {
        data = typeof data === 'object' ? data : {};
        let result = new PageInformation();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["totalCount"] = this.totalCount;
        data["pageSize"] = this.pageSize;
        data["pageIndex"] = this.pageIndex;
        return data;
    }
}

export interface IPageInformation {
    totalCount: number;
    pageSize: number;
    pageIndex: number;
}

export class Npc2 implements INpc2 {
    id!: number;
    name!: string;
    strengthMax!: number;
    strengthMin!: number;
    vitalityMax!: number;
    vitalityMin!: number;
    bodyMax!: number;
    bodyMin!: number;
    agilityMax!: number;
    agilityMin!: number;
    dexterityMax!: number;
    dexterityMin!: number;
    intelligenceMax!: number;
    intelligenceMin!: number;
    willpowerMax!: number;
    willpowerMin!: number;
    emotionMax!: number;
    emotionMin!: number;
    damageReductionMax!: number;
    damageReductionMin!: number;
    skillLevelMax!: number;
    skillLevelMin!: number;
    karma!: number;
    isUndead!: boolean;
    difficulty!: Difficulty;
    merits!: Merit[];
    flaws!: Flaw[];
    weapons!: Weapon[];
    skills!: Skill[];

    constructor(data?: INpc2) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.strengthMax = _data["strengthMax"];
            this.strengthMin = _data["strengthMin"];
            this.vitalityMax = _data["vitalityMax"];
            this.vitalityMin = _data["vitalityMin"];
            this.bodyMax = _data["bodyMax"];
            this.bodyMin = _data["bodyMin"];
            this.agilityMax = _data["agilityMax"];
            this.agilityMin = _data["agilityMin"];
            this.dexterityMax = _data["dexterityMax"];
            this.dexterityMin = _data["dexterityMin"];
            this.intelligenceMax = _data["intelligenceMax"];
            this.intelligenceMin = _data["intelligenceMin"];
            this.willpowerMax = _data["willpowerMax"];
            this.willpowerMin = _data["willpowerMin"];
            this.emotionMax = _data["emotionMax"];
            this.emotionMin = _data["emotionMin"];
            this.damageReductionMax = _data["damageReductionMax"];
            this.damageReductionMin = _data["damageReductionMin"];
            this.skillLevelMax = _data["skillLevelMax"];
            this.skillLevelMin = _data["skillLevelMin"];
            this.karma = _data["karma"];
            this.isUndead = _data["isUndead"];
            this.difficulty = _data["difficulty"];
            if (Array.isArray(_data["merits"])) {
                this.merits = [] as any;
                for (let item of _data["merits"])
                    this.merits!.push(Merit.fromJS(item));
            }
            if (Array.isArray(_data["flaws"])) {
                this.flaws = [] as any;
                for (let item of _data["flaws"])
                    this.flaws!.push(Flaw.fromJS(item));
            }
            if (Array.isArray(_data["weapons"])) {
                this.weapons = [] as any;
                for (let item of _data["weapons"])
                    this.weapons!.push(Weapon.fromJS(item));
            }
            if (Array.isArray(_data["skills"])) {
                this.skills = [] as any;
                for (let item of _data["skills"])
                    this.skills!.push(Skill.fromJS(item));
            }
        }
    }

    static fromJS(data: any): Npc2 {
        data = typeof data === 'object' ? data : {};
        let result = new Npc2();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["strengthMax"] = this.strengthMax;
        data["strengthMin"] = this.strengthMin;
        data["vitalityMax"] = this.vitalityMax;
        data["vitalityMin"] = this.vitalityMin;
        data["bodyMax"] = this.bodyMax;
        data["bodyMin"] = this.bodyMin;
        data["agilityMax"] = this.agilityMax;
        data["agilityMin"] = this.agilityMin;
        data["dexterityMax"] = this.dexterityMax;
        data["dexterityMin"] = this.dexterityMin;
        data["intelligenceMax"] = this.intelligenceMax;
        data["intelligenceMin"] = this.intelligenceMin;
        data["willpowerMax"] = this.willpowerMax;
        data["willpowerMin"] = this.willpowerMin;
        data["emotionMax"] = this.emotionMax;
        data["emotionMin"] = this.emotionMin;
        data["damageReductionMax"] = this.damageReductionMax;
        data["damageReductionMin"] = this.damageReductionMin;
        data["skillLevelMax"] = this.skillLevelMax;
        data["skillLevelMin"] = this.skillLevelMin;
        data["karma"] = this.karma;
        data["isUndead"] = this.isUndead;
        data["difficulty"] = this.difficulty;
        if (Array.isArray(this.merits)) {
            data["merits"] = [];
            for (let item of this.merits)
                data["merits"].push(item.toJSON());
        }
        if (Array.isArray(this.flaws)) {
            data["flaws"] = [];
            for (let item of this.flaws)
                data["flaws"].push(item.toJSON());
        }
        if (Array.isArray(this.weapons)) {
            data["weapons"] = [];
            for (let item of this.weapons)
                data["weapons"].push(item.toJSON());
        }
        if (Array.isArray(this.skills)) {
            data["skills"] = [];
            for (let item of this.skills)
                data["skills"].push(item.toJSON());
        }
        return data;
    }
}

export interface INpc2 {
    id: number;
    name: string;
    strengthMax: number;
    strengthMin: number;
    vitalityMax: number;
    vitalityMin: number;
    bodyMax: number;
    bodyMin: number;
    agilityMax: number;
    agilityMin: number;
    dexterityMax: number;
    dexterityMin: number;
    intelligenceMax: number;
    intelligenceMin: number;
    willpowerMax: number;
    willpowerMin: number;
    emotionMax: number;
    emotionMin: number;
    damageReductionMax: number;
    damageReductionMin: number;
    skillLevelMax: number;
    skillLevelMin: number;
    karma: number;
    isUndead: boolean;
    difficulty: Difficulty;
    merits: Merit[];
    flaws: Flaw[];
    weapons: Weapon[];
    skills: Skill[];
}

export class Merit implements IMerit {
    id!: number;
    name!: number;

    constructor(data?: IMerit) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
        }
    }

    static fromJS(data: any): Merit {
        data = typeof data === 'object' ? data : {};
        let result = new Merit();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        return data;
    }
}

export interface IMerit {
    id: number;
    name: number;
}

export class Flaw implements IFlaw {
    id!: number;
    name!: number;

    constructor(data?: IFlaw) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
        }
    }

    static fromJS(data: any): Flaw {
        data = typeof data === 'object' ? data : {};
        let result = new Flaw();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        return data;
    }
}

export interface IFlaw {
    id: number;
    name: number;
}

export class Weapon implements IWeapon {
    id!: number;
    name!: number;
    attackType!: AttackType;

    constructor(data?: IWeapon) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.attackType = _data["attackType"] ? AttackType.fromJS(_data["attackType"]) : <any>undefined;
        }
    }

    static fromJS(data: any): Weapon {
        data = typeof data === 'object' ? data : {};
        let result = new Weapon();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["attackType"] = this.attackType ? this.attackType.toJSON() : <any>undefined;
        return data;
    }
}

export interface IWeapon {
    id: number;
    name: number;
    attackType: AttackType;
}

export class AttackType implements IAttackType {
    id!: number;
    name!: string;
    numberOfDice!: number;
    extraDamage!: number;

    constructor(data?: IAttackType) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.numberOfDice = _data["numberOfDice"];
            this.extraDamage = _data["extraDamage"];
        }
    }

    static fromJS(data: any): AttackType {
        data = typeof data === 'object' ? data : {};
        let result = new AttackType();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["numberOfDice"] = this.numberOfDice;
        data["extraDamage"] = this.extraDamage;
        return data;
    }
}

export interface IAttackType {
    id: number;
    name: string;
    numberOfDice: number;
    extraDamage: number;
}

export class Skill implements ISkill {
    id!: number;
    name!: number;
    level!: number;

    constructor(data?: ISkill) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.level = _data["level"];
        }
    }

    static fromJS(data: any): Skill {
        data = typeof data === 'object' ? data : {};
        let result = new Skill();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["level"] = this.level;
        return data;
    }
}

export interface ISkill {
    id: number;
    name: number;
    level: number;
}

export class ProblemDetails implements IProblemDetails {
    type!: string | undefined;
    title!: string | undefined;
    status!: number | undefined;
    detail!: string | undefined;
    instance!: string | undefined;

    [key: string]: any;

    constructor(data?: IProblemDetails) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            for (var property in _data) {
                if (_data.hasOwnProperty(property))
                    this[property] = _data[property];
            }
            this.type = _data["type"];
            this.title = _data["title"];
            this.status = _data["status"];
            this.detail = _data["detail"];
            this.instance = _data["instance"];
        }
    }

    static fromJS(data: any): ProblemDetails {
        data = typeof data === 'object' ? data : {};
        let result = new ProblemDetails();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }
        data["type"] = this.type;
        data["title"] = this.title;
        data["status"] = this.status;
        data["detail"] = this.detail;
        data["instance"] = this.instance;
        return data;
    }
}

export interface IProblemDetails {
    type: string | undefined;
    title: string | undefined;
    status: number | undefined;
    detail: string | undefined;
    instance: string | undefined;

    [key: string]: any;
}

export class ApiException extends Error {
    override message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new ApiException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((event.target as any).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}