import { TestBed } from '@angular/core/testing';

import { WebMotorsService } from './web-motors.service';

describe('WebMotorsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WebMotorsService = TestBed.get(WebMotorsService);
    expect(service).toBeTruthy();
  });
});
