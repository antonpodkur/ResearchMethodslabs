package com.example.lab1a

import android.R.attr
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.example.lab1a.databinding.ActivityMainBinding


class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        val view = binding.root
        setContentView(view)


        binding.button.setOnClickListener(){
            var edNumber = binding.textInputEditText
            var text = binding.textView
            var iterText = binding.iterationsText

            var iterations = 0

            try {
                val number = edNumber.text.toString().toInt()
                if (number % 2 == 0) {
                    text.text = (number / 2).toString() + "*" + "2"
                    iterText.text = "Iterations needed: " + iterations
                } else {
                    var x = Math.ceil(Math.sqrt(number.toDouble())).toInt()
                    while ((Math.pow( Math.sqrt(x * x - number.toDouble()).toDouble(), 2.0)) != (x * x - number).toDouble()) {
                        x += 1
                        iterations++
                    }
                    val y = Math.sqrt((x * x - number).toDouble()).toInt()
                    text.text = (x - y).toString() + "*" + (x + y)
                    iterText.text = "Iterations needed: " + iterations
                }
            } catch (e: Exception) {
                text.text = "Error!"
            }
        }
    }
}
