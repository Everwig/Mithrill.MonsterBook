import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs';

export class ObservableDataSource<T> extends DataSource<T> {
  constructor(private source$: Observable<T[]>) {
    super();
  }

  connect(collectionViewer: CollectionViewer): Observable<readonly T[]> {
    return this.source$;
  }

  disconnect(collectionViewer: CollectionViewer): void {}
}