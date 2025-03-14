import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SampleStoreComponent } from './sample-store.component';

describe('SampleStoreComponent', () => {
  let component: SampleStoreComponent;
  let fixture: ComponentFixture<SampleStoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SampleStoreComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SampleStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
