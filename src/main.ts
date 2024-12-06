import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { importProvidersFrom } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'; // Import du module HttpClient
import { AppComponent } from './app/app.component';
import { appRoutes } from './app/app.routes';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(appRoutes),                   // Fournir les routes
    importProvidersFrom(FormsModule, HttpClientModule), // Importer FormsModule et HttpClientModule
  ],
}).catch((err) => console.error(err));
