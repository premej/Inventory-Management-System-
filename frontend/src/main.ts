import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes'; // Make sure this file exists and is correct
import { AuthService } from './app/services/auth.service';
bootstrapApplication(AppComponent, {
 providers: [
    provideRouter(routes),
    provideHttpClient(withFetch()),
    AuthService 
]
}).catch(err => console.error(err));