import { BaseModel } from '../base/BaseModel';
import { MajorEnum } from '../enums/MajorEnums';
import { SubjectTypeEnum } from '../enums/SubjectEnums';

export class SubjectModel extends BaseModel {
  name: string;
  credits: number;
  major: MajorEnum;
  subjectType: SubjectTypeEnum;

  constructor(
    id: string,
    name: string,
    credits: number,
    major: MajorEnum,
    subjectType: SubjectTypeEnum
  ) {
    super(id);
    this.name = name;
    this.credits = credits;
    this.major = major;
    this.subjectType = subjectType;
  }
}
