import { ValidationErrors } from '@angular/forms';

import { ValidationError } from './validation-error.model';

export class ValidationResult {
  constructor(public isValid: boolean, public validationErrors: ValidationError[]) {}

  public getPropertyErrors(propertyName: string): ValidationErrors | null {
    if (!this.validationErrors || this.validationErrors.length === 0) {
      return null;
    }

    const errorMessages = this.validationErrors
      .filter((propertyError) => propertyError.propertyName === propertyName)
      .map((propertyError) => propertyError.errorMessage);

    return errorMessages.length ? { messages: errorMessages } : null;
  }
}