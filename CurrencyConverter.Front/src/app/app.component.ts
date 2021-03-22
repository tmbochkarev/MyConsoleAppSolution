import { Component } from '@angular/core';
     
@Component({
    selector: 'app',
    templateUrl: './app.component.html'
})
export class AppComponent { 

    public rubles: number;

    public convetResults: any = [];

    public convert(): void {
        // вот это можно поменять на обращение к апи
        fetch('https://www.cbr-xml-daily.ru/daily_json.js')
            .then(res => res.json())
            .then(json => {
                const valutes = json.Valute;
                this.convetResults = Object.keys(valutes).map(key => {
                    return {
                        name: valutes[key].Name,
                        value: (this.rubles / (+valutes[key].Value) * (+valutes[key].Nominal)).toFixed(2)
                    }
                });
            });
    }
}