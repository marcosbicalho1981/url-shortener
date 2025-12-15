import { Component } from '@angular/core';
import { UrlService } from './services/url.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'url-shortener-ui';

  originalUrl = '';
  alias = '';
  shortUrl = '';

  constructor(private urlService: UrlService) {}

    generate() {
    this.urlService.create(this.originalUrl, this.alias)
      .subscribe(result => {
        this.shortUrl = `https://localhost:7210/${result.code}`;
      });
    }
}
