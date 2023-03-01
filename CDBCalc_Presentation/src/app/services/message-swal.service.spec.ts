import { TestBed } from '@angular/core/testing';

import { MessageSwalService } from './message-swal.service';

describe('MessageSwalService', () => {
  let service: MessageSwalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MessageSwalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
