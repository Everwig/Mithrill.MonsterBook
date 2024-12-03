export class ValidationError {
  constructor(public propertyName: string, public errorCode: string, public errorMessage: string) {}
}